import React from 'react';
import './App.css';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import NavigationComponent from "./Components/Navigation/Navigation";
import Home from "./Components/HomePage/Home";
import GetUserDetailsForm from "./Components/Forms/GetUserDetailsForm";
import DeterminateCategoryForm from "./Components/Forms/DeterminateCategoryForm";
import PermitNotGrantedComponent from "./Components/ErrorPages/PermitNotGranted";
import GetUserEmailForm from "./Components/Forms/GetUserEmailForm";
import EmailVerificationForm from "./Components/Forms/EmailVerificationForm";

function App() {
    return (
        <div className={"wrapper"}>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home/>}></Route>
                    <Route path="/poziadanieVstupu/zistenieKategorie" element={<DeterminateCategoryForm/>}></Route>
                    <Route path="/poziadanieVstupu/ziskanieEmailu" element={<GetUserEmailForm/>}></Route>
                    <Route path="/poziadanieVstupu/overenieEmailu" element={<EmailVerificationForm/>}></Route>
                    <Route path="/poziadanieVstupu/ziskanieUdajov" element={<GetUserDetailsForm/>}></Route>
                    <Route path="/poziadanieVstupu/vstupZamietnuty" element={<PermitNotGrantedComponent/>}></Route>
                    <Route path="*" element={<Home/>}></Route>
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
