import React, {useState} from "react";
import {Button, Container, Nav, Navbar, Offcanvas} from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";

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
    return (
        <div>
            <div>{localization.title}</div>
            <TextField style={{width: 500}} label={"Email"} required value={email}
                       onChange={(e) => {
                           setEmail(e.target.value)
                       }}/>
            <Button className={"me-2"} variant={"danger"} onClick={() => navigate("/")}>Zrušiť</Button>
            <Button className={"me-2"} variant={"success"} onClick={() => console.log("Na email Vám bol zaslaný registračný link")}>Over mail</Button>
        </div>
    )
}

export default GetUserEmailForm;