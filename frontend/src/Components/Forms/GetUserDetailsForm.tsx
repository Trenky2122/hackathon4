import React, {useEffect, useState} from "react";
import {Button, Container, Nav, Navbar, Offcanvas} from "react-bootstrap";
import {Link, useNavigate, useParams} from "react-router-dom";
import LocalizedStrings from "react-localization";
import TextField from "@material-ui/core/TextField";
import SuccessfulPopUp from "../PopUp/SuccessfulPopUp";

const GetUserDetailsForm = () => {
    let navigate = useNavigate();
    let [name, setName] : [string, any] = useState("");
    let [surname, setSurname] : [string, any] = useState("");
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    let [registrationSuccessful, setRegistrationSuccessful] : [boolean, any] = useState(false);
    const { verificationKey } = useParams();

    const localization = new LocalizedStrings({
        en: {
            title: "Get user details",
        },
        sk: {
            title: "Získanie údajov o používateľovi",
        }
    });

    useEffect(() => {
        console.log(verificationKey)
        // Zavolaj backend service aby zistil ze ci existuje taky verif key
        // AK existuje tak daj aj email nech ho mozem vlozit do premennej email
        setEmail("TODO: Email z DB")
    }, [])

    const handleSubmit = (e: any) => {
        e.preventDefault()
        setRegistrationSuccessful(true)
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div>{localization.title}</div>
                <TextField style={{width: 500}} label={"Meno"} required autoFocus value={name}
                           onChange={(e) => {
                               setName(e.target.value)
                           }}/>
                <TextField style={{width: 500}} label={"Priezvisko"} required value={surname}
                           onChange={(e) => {
                               setSurname(e.target.value)
                           }}/>
                <TextField style={{width: 500}} label={"Email"} required disabled value={email}/>
                <TextField style={{width: 500}} label={"Heslo"} value={password}
                           onChange={(e) => {
                               setPassword(e.target.value)
                           }}/>
                <Button className={"me-2"} type={"submit"} variant={"success"} onClick={() => console.log("")}>Dokončiť registráciu</Button>
            </form>
            <SuccessfulPopUp
                TitleText={"Registrácia úspešná"}
                BodyText={"Gratulujeme. Úspešne ste zaregistrovaný. Môžete požiadať o žiadosť."}
                ButtonUrl={"/profil"}
                ButtonText={"Môj profil"}
                show={registrationSuccessful}
            />
        </div>
    )
}

export default GetUserDetailsForm;