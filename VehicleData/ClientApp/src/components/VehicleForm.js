import React, { useEffect } from "react";
import { Typography, Grid, TextField, withStyles, Button } from "@material-ui/core";
import useForm from "./useForm";
import { connect } from "react-redux";
import * as actions from "../actions/VehicleAction";
import { useToasts } from "react-toast-notifications";

const styles = theme => ({
    root: {
        '& .MuiTextField-root': {
            margin: theme.spacing(1),
            minWidth: 230,
        }
    },
    formControl: {
        margin: theme.spacing(1),
        minWidth: 230,
    },
    smMargin: {
        margin: theme.spacing(1)
    }
})

const initialFieldValues = {
    make: '',
    model: '',
    year: ''
}

const VehicleForm = ({ classes, ...props }) => {

    const { addToast } = useToasts()

    const validate = (fieldValues = values) => {
        let temp = { ...errors }
        if ('make' in fieldValues)
            temp.make = fieldValues.make ? "" : "This field is required."
        if ('model' in fieldValues)
            temp.model = fieldValues.model ? "" : "This field is required."
        if ('year' in fieldValues)
            temp.year = (/^19[5-9]\d|20[0-4]\d|2050$/).test(fieldValues.year) ? "" : "Enter year between 1950 and 2050!"
        setErrors({
            ...temp
        })

        if (fieldValues == values)
            return Object.values(temp).every(x => x == "")
    }

    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetForm
    } = useForm(initialFieldValues, validate, props.setCurrentId, props.setEditMode)

    const handleSubmit = e => {
        e.preventDefault()
        if (validate()) {
            const onSuccess = () => {
                resetForm()
                addToast("Submitted successfully", { appearance: 'success' })
            }
            if (props.currentId == 0)
                props.createVehicle(values, onSuccess)
            else
                props.updateVehicle(props.currentId, values, onSuccess)
        }
    }

    useEffect(() => {
        if (props.currentId != 0) {
            setValues({
                ...props.vehicleList.find(x => x.id == props.currentId)
            })
            setErrors({})
        }
    }, [props.currentId])

    return (
        <React.Fragment>
            <form autoComplete="off" noValidate className={classes.root} onSubmit={handleSubmit}>
                <Typography variant="h6" component="h1">
                    {props.editMode ? "Edit" : "Add"} Vehicles
                </Typography>
                <Grid container>
                    <Grid item xs={6}>
                        <TextField
                            name="make"
                            variant="outlined"
                            label="Make"
                            value={values.make}
                            onChange={handleInputChange}
                            {...(errors.make && { error: true, helperText: errors.make })}
                        />
                        <TextField
                            name="model"
                            variant="outlined"
                            label="Model"
                            value={values.model}
                            onChange={handleInputChange}
                            {...(errors.model && { error: true, helperText: errors.model })}
                        />
                        <TextField
                            name="year"
                            variant="outlined"
                            label="Year"
                            value={values.year}
                            onChange={handleInputChange}
                            {...(errors.year && { error: true, helperText: errors.year })}
                        />

                        <div>
                            <Button
                                variant="contained"
                                color="primary"
                                type="submit"
                                className={classes.smMargin}
                            >
                                {props.editMode ? "Edit" : "Add"}
                            </Button>
                            <Button
                                variant="contained"
                                className={classes.smMargin}
                                onClick={resetForm}
                            >
                                Clear
                            </Button>
                        </div>
                    </Grid>
                </Grid>
            </form>
        </React.Fragment>
    );
}


const mapStateToProps = state => ({
    vehicleList: state.vehicle.list
})

const mapActionToProps = {
    createVehicle: actions.create,
    updateVehicle: actions.update
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(VehicleForm));