import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/VehicleAction";
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, withStyles, ButtonGroup, Button } from "@material-ui/core";
import VehicleForm from "./VehicleForm";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import { useToasts } from "react-toast-notifications";

const styles = theme => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }
})

const Vehicles = ({ classes, ...props }) => {
    const [currentId, setCurrentId] = useState(0);
    const [editMode, setEditMode] = useState(false);

    useEffect(() => {
        props.fetchAllVehicles()
    }, [])
    
    const { addToast } = useToasts()

    const onDelete = id => {
        if (window.confirm('Are you sure to delete this record?'))
            props.deleteVehicle(id,()=>addToast("Deleted successfully", { appearance: 'info' }))
    }

    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={6}>
                    <VehicleForm {...({ currentId, setCurrentId, editMode, setEditMode })} />
                </Grid>
                <Grid item xs={6}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Sl.no</TableCell>
                                    <TableCell>Make</TableCell>
                                    <TableCell>Model</TableCell>
                                    <TableCell>Year</TableCell>
                                    <TableCell></TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.vehicleList.map((vehicleRecord, index) => {
                                        return (<TableRow key={index} hover>
                                            <TableCell>{index+1}</TableCell>
                                            <TableCell>{vehicleRecord.make}</TableCell>
                                            <TableCell>{vehicleRecord.model}</TableCell>
                                            <TableCell>{vehicleRecord.year}</TableCell>
                                            <TableCell>
                                                <ButtonGroup variant="text">
                                                    <Button><EditIcon color="primary"
                                                        onClick={() => { 
                                                            setCurrentId(vehicleRecord.id);
                                                            setEditMode(true)}} />
                                                    </Button>
                                                    <Button><DeleteIcon color="secondary"
                                                        onClick={() => onDelete(vehicleRecord.id)} /></Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>)
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
    );
}

const mapStateToProps = state => ({
    vehicleList: state.vehicle.list
})

const mapActionToProps = {
    fetchAllVehicles: actions.fetchAll,
    deleteVehicle: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(Vehicles));