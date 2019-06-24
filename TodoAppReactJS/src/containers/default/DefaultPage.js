import React, { Component } from 'react'
import { Route, NavLink, Switch, Redirect } from 'react-router-dom';
import routes from './../../routes';
export default class DefaultPage extends Component {
    loading = () => <div>Loading...</div>
    render() {
        return (
            <div className="defaultgape">
                <NavLink activeClassName="active" to="/dashboard">Dashboard</NavLink>
                <NavLink activeClassName="active" to="/profile">Profile</NavLink>
                <div className="inroute">
                    <React.Suspense fallback={this.loading()}>
                        <Switch>
                            {routes.map((route, idx) => {
                                return route.component ? (
                                    <Route
                                        key={idx}
                                        path={route.path}
                                        exact={route.exact}
                                        name={route.name}
                                        render={props => (
                                            <route.component {...props} />
                                        )} />
                                ) : (null);
                            })}
                            <Redirect from="/" to="/dashboard" />
                        </Switch>
                    </React.Suspense>
                </div>
            </div>
        )
    }
}

