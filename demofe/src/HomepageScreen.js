import React from 'react';

export default class HomepageScreen extends React.Component {
    render() {
        return(
            <div>
                <h1>{ this.props.Title }</h1>
                <p>{ this.props.Description }</p>
            </div>
        );
    }
}