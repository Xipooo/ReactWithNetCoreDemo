import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import HomepageScreen from './HomepageScreen';

class App extends Component {
  constructor(){
    super();
    this.state = {Title: "", Description: ""}
  }

  componentDidMount(){
    fetch("http://localhost:5000/api/HomePage")
    .then(resp => resp.json())
    .then(resJson => this.updateData(resJson.title, resJson.description));
  }

  updateData(title, description){
    this.setState({Title: title, Description: description});
  }

  render() {
    return (
      <div>
        <HomepageScreen Title={this.state.Title} Description={this.state.Description} />
      </div>
    );
  }
}

export default App;
