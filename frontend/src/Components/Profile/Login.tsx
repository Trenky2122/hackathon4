import React, {useEffect, useState} from "react";
import {Alert, Button} from "react-bootstrap";
import {useNavigate, useParams} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";
import SuccessfulPopUp from "../PopUp/SuccessfulPopUp";
import {Simulate} from "react-dom/test-utils";
import error = Simulate.error;

const LoginComponent = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    let [errorMessage, setErrorMessage] : [string, any] = useState("");
    let [loginSuccessful, setLoginSuccessful] : [boolean, any] = useState(false);

    const localization = new LocalizedStrings({
        en: {
            title: "User login",
        },
        sk: {
            title: "Prihlásenie používateľa",
        }
    });

    const handleSubmit = (e: any) => {
        e.preventDefault()
        // Zavolaj backend endpoint aby si zistil ci su prihlasovacie udaje spravne
        if(password == "admin") {
            setLoginSuccessful(true)
        }
        else {
            setErrorMessage("Email alebo heslo je nesprávne")
        }
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div>{localization.title}</div>
                <TextField style={{width: 500}} label={"Email"} required autoFocus value={email}
                           onChange={(e) => {
                               setEmail(e.target.value);
                               setErrorMessage("");
                           }}/>
                <TextField style={{width: 500}} label={"Heslo"} required value={password}
                           onChange={(e) => {
                               setPassword(e.target.value);
                               setErrorMessage("");
                           }}/>
                <Button className={"me-2"} type={"submit"} variant={"success"}>Prihlásiť sa</Button>
            </form>
            <SuccessfulPopUp
                TitleText={"Login úspešný"}
                BodyText={"Gratulujeme. Úspešne ste sa prihlásili do Vášho účtu."}
                ButtonUrl={"/profil"}
                ButtonText={"Pokračovať"}
                show={loginSuccessful}
            />
            {errorMessage != '' &&
                <Alert key={"danger"} variant={"danger"}>
                    {errorMessage}
                </Alert>
            }

        </div>
    )
}

export default LoginComponent;