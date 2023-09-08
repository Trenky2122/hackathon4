import React, {useEffect, useState} from "react";
import {Alert, Button} from "react-bootstrap";
import {useNavigate, useParams} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";
import MessagePopUp from "../PopUp/MessagePopUp";
import {Simulate} from "react-dom/test-utils";
import error = Simulate.error;
import BackgroundImage from "../../Images/BackgroundImage";

const LoginComponent = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    let [errorMessage, setErrorMessage] : [string, any] = useState("");
    let [loginError, setLoginError] : [boolean, any] = useState(false);

    const localization = new LocalizedStrings({
        en: {
            title: "Login",
        },
        sk: {
            title: "Prihlásenie",
        }
    });

    const handleSubmit = (e: any) => {
        e.preventDefault()
        // Zavolaj backend endpoint aby si zistil ci su prihlasovacie udaje spravne
        if(password == "admin") {
            navigate("/profil")
        }
        else {
            setLoginError(true)
        }
    }

    return (
        <div>
            <div className={"container"}>
                <div className={"row justify-content-center"} >
                    <div className={"col-3 homepageForm"}>
                        <form onSubmit={handleSubmit}>
                            <h1 style={{marginBottom: "30px"}}>{localization.title} </h1>
                            <TextField label={"Email"} required autoFocus value={email}
                                       onChange={(e) => {
                                           setEmail(e.target.value);
                                           setErrorMessage("");
                                       }} fullWidth />
                            <TextField label={"Heslo"} required value={password}
                                       onChange={(e) => {
                                           setPassword(e.target.value);
                                           setErrorMessage("");
                                       }} fullWidth />
                            <Button className={"me-2 mt-3"} type={"submit"} variant={"success"}>Prihlásiť sa</Button>
                        </form>
                    </div>
                </div>
            </div>
            <MessagePopUp
                TitleText={"Chyba"}
                BodyText={"Nesprávne prihlasovacie meno alebo heslo. Skúste znovu."}
                ButtonUrl={""}
                ButtonText={"Skúsiť znovu"}
                show={loginError}
            />
        </div>
    )
}

export default LoginComponent;