import React from 'react';
import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import NavigationComponent from "./Components/Navigation/Navigation";
import Home from "./Components/HomePage/Home";

function App() {
    return (
        <div className={"wrapper"}>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home/>}></Route>
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
