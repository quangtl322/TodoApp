import React from 'react';
import { Button } from 'reactstrap';
import { connect } from 'react-redux'
import * as actions from './../../redux/actions';

const Item = (props) => {
    const onDelete = (id) => {
        props.onDelete(id);
    }
    return (
        <div className="item">
            {props.data.username} _ {props.data.password} _ {props.data.id}
            <Button onClick={() => onDelete(props.data.id)} color="danger">Delete</Button>
        </div>
    )
}
const matchStateToProps = (state) => {
    return {

    }
}
const mapDispatchToProps = (dispatch) => {
    return {
     
    }
}


export default connect(matchStateToProps, mapDispatchToProps)(Item)