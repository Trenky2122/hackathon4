import React from 'react';
import './App.css';
import {BrowserRouter, Navigate, Route, Routes} from "react-router-dom";
import NavigationComponent from "./Components/Navigation/Navigation";
import Home from "./Components/HomePage/Home";
import GetUserDetailsForm from "./Components/Forms/GetUserDetailsForm";
import DeterminateCategoryForm from "./Components/Forms/DeterminateCategoryForm";
import PermitNotGrantedComponent from "./Components/ErrorPages/PermitNotGranted";
import GetUserEmailForm from "./Components/Forms/GetUserEmailForm";
import Unauthorized from './Components/ErrorPages/Unauthorized';
import NotFound from './Components/ErrorPages/NotFound';
import UserEntriesHistoryComponent from './Components/Profile/UserEntriesHistory';
import 'bootstrap/dist/css/bootstrap.min.css';
import ProfileComponent from "./Components/Profile/Profile";

function App() {
    return (
        <div className={"wrapper"}>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Home/>}></Route>

                    <Route path="/poziadanieVstupu/zistenieKategorie" element={<DeterminateCategoryForm/>}></Route>
                    <Route path="/poziadanieVstupu/ziskanieEmailu" element={<GetUserEmailForm/>}></Route>
                    <Route path="/poziadanieVstupu/ziskanieUdajov/:verificationKey" element={<GetUserDetailsForm/>}></Route>
                    <Route path="/poziadanieVstupu/vstupZamietnuty" element={<PermitNotGrantedComponent/>}></Route>

                    <Route path="/profil" element={<ProfileComponent/>}></Route>
                    <Route path="/profil/žiadosti" element={<NotFound/>}></Route>
                    <Route path="/profil/históriaVstupov" element={<UserEntriesHistoryComponent/>}></Route>

                    <Route path="/401" element={<Unauthorized/>}/>
                    <Route path="/404" element={<NotFound/>}/>
                    <Route path={"/*"} element={<Navigate to='/404' />}/>
                </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
