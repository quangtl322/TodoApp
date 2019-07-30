import { takeEvery, call, put, all } from "redux-saga/effects";
import axios from 'axios';
import qs from 'qs';
import * as actionTypes from "./../actions/actionType";
import * as actions from "./../actions"
const instance = axios.create({
    timeout: 10000
});

const getEmployee = (params) => {
    return instance.get("https://localhost:44373/api/employee", {
        params,
        paramsSerializer: (params) => {
            return qs.stringify(params, { arrayFormat: "repeat" });
        }
    })
        .then(res => {
            //  console.log(res)
            return res.data;
        })
        .catch(e => {
            // console.log(e)
            throw e;
        })
}

function* getEmployeeSaga(action) {
    try {
        const payload = yield call(() => getEmployee(action.params));
        console.log(payload)
        yield put(actions.getEmployeeSuccess(payload))
    } catch (error) {
        // console.log(error)
        yield put(actions.getEmployeeFail(error))
    }
}


export function* watchEmployeeAsync() {
    yield all([
        takeEvery(actionTypes.GET_EMPLOYEES_START, getEmployeeSaga),
    ]);
}

