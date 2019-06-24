import { all, fork } from "redux-saga/effects";
import { watchEmployeeAsync } from './employee.saga';
export default function* sagas() {
    yield all([
        fork(watchEmployeeAsync),
    ]);
}