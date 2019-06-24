import { createStore, applyMiddleware, compose } from 'redux';
import reducers from './../reducers';
import createSagaMiddleware from 'redux-saga';
import sagas from './../sagas';
// const initialState = {};
const composeEnhancers =
    process.env.NODE_ENV === "development"
        ? window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__
        : null || compose;
const sagaMiddleware = createSagaMiddleware();

export const store = createStore(reducers, composeEnhancers(applyMiddleware(sagaMiddleware)));
sagaMiddleware.run(sagas)

console.log(store.getState());