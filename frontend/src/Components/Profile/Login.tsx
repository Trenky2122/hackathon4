import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate, useParams} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";
import SuccessfulPopUp from "../PopUp/SuccessfulPopUp";

const LoginComponent = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    let [loginSuccessful, setLoginSuccessful] : [boolean, any] = useState(false);
    const { verificationKey } = useParams();

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
            setLoginSuccessful(false)
        }
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div>{localization.title}</div>
                <TextField style={{width: 500}} label={"Email"} required autoFocus value={email}
                           onChange={(e) => {
                               setEmail(e.target.value)
                           }}/>
                <TextField style={{width: 500}} label={"Heslo"} required value={password}
                           onChange={(e) => {
                               setPassword(e.target.value)
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
        </div>
    )
}

export default LoginComponent;