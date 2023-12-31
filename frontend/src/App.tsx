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
import LoginComponent from "./Components/Profile/Login";
import RequestsComponent from "./Components/Profile/Requests";
import BackgroundImage from "./Images/BackgroundImage";
import {Constants} from "./Constants/Constants";
import {GoogleReCaptchaProvider} from "react-google-recaptcha-v3";
import CompleteRequestForm from "./Components/Forms/CompleteRequestForm";
import AdminMainPage from "./Components/Admin/AdminMainPage";
import EntranceRequestDetailed from "./Components/Admin/EntranceRequestDetailed";

function App() {
    return (
        <div className={"wrapper"}>
            <BrowserRouter>
                <NavigationComponent/>
                <BackgroundImage/>
                <GoogleReCaptchaProvider reCaptchaKey={Constants.RECAPTCHA_SITE_KEY}>

                <Routes>
                    <Route path="/" element={<Home/>}></Route>

                    <Route path="/registracia/ziskanieEmailu" element={<GetUserEmailForm/>}></Route>
                    <Route path="/registracia/ziskanieUdajov/:verificationKey" element={<GetUserDetailsForm/>}></Route>

                    <Route path="/prihlasenie" element={<LoginComponent/>}></Route>

                    <Route path="/profil" element={<ProfileComponent/>}></Route>
                    <Route path="/profil/ziadosti" element={<RequestsComponent/>}></Route>
                    <Route path="/profil/historiaVstupov" element={<UserEntriesHistoryComponent/>}></Route>

                    <Route path="/ziadost/kategorizacia" element={<DeterminateCategoryForm/>}></Route>
                    <Route path="/ziadost/kategoria/:caseIndex" element={<CompleteRequestForm/>}></Route>
                    <Route path="/ziadost/zamietnuta" element={<PermitNotGrantedComponent/>}></Route>

                    <Route path="/admin/ziadosti" element={<AdminMainPage />}></Route>
                    <Route path="/admin/ziadosti/:id" element={<EntranceRequestDetailed />}></Route>

                    <Route path="/401" element={<Unauthorized/>}/>
                    <Route path="/404" element={<NotFound/>}/>
                    <Route path="/*" element={<Navigate to='/404'/>}/>
                </Routes>

                </GoogleReCaptchaProvider>
            </BrowserRouter>
        </div>
    );
}

export default App;
