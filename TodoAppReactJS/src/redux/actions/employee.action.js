import * as actionTypes from './actionType';

export const getEmployee = (params) => {
    return {
        type: actionTypes.GET_EMPLOYEES_START,
        params
    }
}
export const getEmployeeSuccess = (payload) => {
    return {
        type: actionTypes.GET_EMPLOYEES_SUCCESS,
        payload
    }
}
export const getEmployeeFail = (error) => {
    return {
        type: actionTypes.GET_EMPLOYEES_START,
        error
    }
}
