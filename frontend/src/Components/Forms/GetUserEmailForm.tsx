import React, {useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";
import * as EmailValidator from 'email-validator';

const GetUserEmailForm = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    const localization = new LocalizedStrings({
        en: {
            title: "Get user details",
        },
        sk: {
            title: "Získanie údajov o používateľovi",
        }
    });

    const handleSubmit = (e: any) => {
        e.preventDefault()
        if(EmailValidator.validate(email)){
            console.log("Posielam mail na", email)
        }
        else{
            console.log("Neplatný mail")
        }
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div>{localization.title}</div>
                <TextField style={{width: 500}} label={"Email"} required value={email}
                           onChange={(e) => {
                               setEmail(e.target.value)
                           }}/>
                <Button className={"me-2"} variant={"danger"} onClick={() => navigate("/")}>Zrušiť</Button>
                <Button className={"me-2"} type={"submit"} variant={"success"}>Over mail</Button>
            </form>
        </div>
    )
}

export default GetUserEmailForm;