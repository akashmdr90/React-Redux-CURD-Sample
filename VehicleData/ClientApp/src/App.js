import React from 'react';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import Vehicles from './components/Vehicles';
import { Container } from "@material-ui/core";
import { ToastProvider } from "react-toast-notifications";
import Navbar from "./NavBar";

function App() {
  return (
    <Provider store={store}>
      <Navbar/>
      <ToastProvider autoDismiss={true}>
        <Container maxWidth="lg">
          <Vehicles />
        </Container>
      </ToastProvider>
    </Provider>
  );
}

export default App;
