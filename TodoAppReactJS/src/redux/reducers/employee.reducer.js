import * as actionTypes from '../actions/actionType';

const initSate = {
    employees: [],
    isActive: false,
    message: 'No request',
    fetching: false,
    fetched: false,
    error: '',
};

const getEmployeeStart = (state, action) => {
    return {
        ...state,
        fetching: true,
        message: 'Loading...'
    }
}

const getEmployeeSuccess = (state, action) => {
    return {
        ...state,
        employees: action.payload,
        fetching: false,
        fetched: true,
        message: 'Done'
    }
}

const getEmployeeFail = (state, action) => {
    return {
        ...state,
        fetching: false,
        message: '',
        error: action.error
    }
}
export default function employeeReducer(state = initSate, action) {
    switch (action.type) {
        case actionTypes.GET_EMPLOYEES_START:
            return getEmployeeStart(state, action)
        case actionTypes.GET_EMPLOYEES_SUCCESS:
            return getEmployeeSuccess(state, action)
        case actionTypes.GET_EMPLOYEES_FAIL:
            return getEmployeeFail(state, action)
        default:
            return state;
    }
}
