import React, {useState} from "react";
import {Button, Container, Nav, Navbar, Offcanvas} from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";

const GetUserDetailsForm = () => {
    let navigate = useNavigate();
    let [name, setName] : [string, any] = useState("");
    let [surname, setSurname] : [string, any] = useState("");
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    const localization = new LocalizedStrings({
        en: {
            title: "Get user details",
        },
        sk: {
            title: "Získanie údajov o používateľovi",
        }
    });
    return (
        <div>
            <div>{localization.title}</div>
            <TextField style={{width: 500}} label={"Meno"} required autoFocus value={name}
                onChange={(e) => {
                    setName(e.target.value)
                }}/>
            <TextField style={{width: 500}} label={"Priezvisko"} required value={surname}
                       onChange={(e) => {
                           setSurname(e.target.value)
                       }}/>
            <TextField style={{width: 500}} label={"Email"} required value={email}
                       onChange={(e) => {
                           setEmail(e.target.value)
                       }}/>
            <TextField style={{width: 500}} label={"Heslo"} value={password}
                       onChange={(e) => {
                           setPassword(e.target.value)
                       }}/>
            <Button className={"me-2"} variant={"success"} onClick={() => console.log("")}>Uložiť</Button>

        </div>
    )
}

export default GetUserDetailsForm;