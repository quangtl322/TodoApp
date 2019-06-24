import React from 'react';

const Dashboard = React.lazy(() => import('./containers/Dashboard'));
const Profile = React.lazy(() => import('./containers/Profile'));
// const Page404 = React.lazy(() => import('./containers/Page404'));
const routes = [
    { path: '/', exact: true, name: 'Home' },
    { path: '/dashboard', name: 'Dashboard', component: Dashboard },
    { path: '/profile', name: 'Profile', component: Profile },
  
];

export default routes;