import React, {useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";
import * as EmailValidator from 'email-validator';
import SuccessfulPopUp from "../PopUp/SuccessfulPopUp";
import BackgroundImage from "../../Images/BackgroundImage";

const GetUserEmailForm = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    let [emailSent, setEmailSent] : [boolean, any] = useState(false);
    let [errorMessage, setErrorMessage] : [string, any] = useState(" ");
    const localization = new LocalizedStrings({
        en: {
            title: "Get user email",
        },
        sk: {
            title: "Zadajte Váš email",
        }
    });

    const handleSubmit = (e: any) => {
        e.preventDefault()
        if(EmailValidator.validate(email)){
            console.log("Posielam mail na", email)
            // Zavolaj backend endpoint s parametrom mail
            // Backend endpiont nech vytvori gui, a prida data ako mail, cas, gui do tabulky
            setEmailSent(true)
        }
        else{
            setErrorMessage("Neplatný mail")
        }
    }

    return (
        <div>
            <BackgroundImage/>
            <div className={"container"}>
                <div className={"row justify-content-center"} >
                    <div className={"col-3 homepageForm"}>
                        <form onSubmit={handleSubmit}>
                        <h1 style={{marginBottom: "30px"}}>{localization.title} </h1>
                            <TextField className={"mb-3"} label={"Email"} required value={email}
                                       onChange={(e) => {
                                           setEmail(e.target.value);
                                           setErrorMessage(" ");
                                       }} error={errorMessage != " "} helperText={errorMessage} fullWidth={true} />
                            <Button className={"me-2"} variant={"danger"} onClick={() => navigate("/")}>Zrušiť</Button>
                            <Button className={"me-2"} type={"submit"} variant={"success"}>Over mail</Button></form>
                    </div>
                </div>
            </div>
            <SuccessfulPopUp
                TitleText={"Email poslaný"}
                BodyText={"Email s unikátnym linkom Vám bol odoslaný na mailovú adresu. Link má dobu expirácie 1 deň."}
                ButtonUrl={"/"}
                ButtonText={"Domov"}
                show={emailSent}
            />
        </div>
    )
}

export default GetUserEmailForm;