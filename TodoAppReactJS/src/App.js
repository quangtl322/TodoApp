import React, { Component } from 'react';
//import Login from './containers/Login';
//import DefaultPage from './containers/default/DefaultPage';
import { BrowserRouter, Route, NavLink, Switch } from 'react-router-dom';
import './App.css';


const DefaultPage = React.lazy(() => import('./containers/default/DefaultPage'));
const Login = React.lazy(() => import('./containers/Login'));
// const Page404 = React.lazy(() => import('./containers/Page404'));


const loading = () => (<div>Loading...</div>)
class App extends Component {
  render() {
    return (
      <BrowserRouter basename="/">
        <div className="App">
          <div style={{ height: "50px" }}>
            <NavLink activeClassName="active" exact to="/">DefaultPage</NavLink>
            <NavLink activeClassName="active" to="/login">Login</NavLink>
          </div>
          <div className="router-component">
            <React.Suspense fallback={loading()}>
              <Switch>
                <Route exact path="/login" name="Login" render={props => <Login {...props} />} />
                <Route path="/" name="Home" render={props => <DefaultPage {...props} />} />
              </Switch>
            </React.Suspense>
          </div>
        </div>
      </BrowserRouter>
    );
  }
}
export default App;
