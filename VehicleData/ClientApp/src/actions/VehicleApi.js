import axios from "axios";

const baseUrl = "https://localhost:44328/api/"

export default {

    vehicle(url = baseUrl + 'Vehicles/') {
        return {
            fetchAll: () => axios.get(url),
            fetchById: id => axios.get(url + id),
            create: newRecord => axios.post(url, newRecord),
            update: (updateRecord) => axios.put(url, updateRecord),
            delete: id => axios.delete(url + id)
        }
    }
}