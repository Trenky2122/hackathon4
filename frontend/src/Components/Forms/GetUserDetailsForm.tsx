import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate, useParams} from "react-router-dom";
import TextField from "@material-ui/core/TextField";
import MessagePopUp from "../PopUp/MessagePopUp";

const GetUserDetailsForm = () => {
    let navigate = useNavigate();
    let [name, setName] : [string, any] = useState("");
    let [surname, setSurname] : [string, any] = useState("");
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    let [idNumber, setIdNumber] : [string, any] = useState("");
    let [registrationSuccessful, setRegistrationSuccessful] : [boolean, any] = useState(false);
    const { verificationKey } = useParams();

    useEffect(() => {
        console.log(verificationKey)
        // Zavolaj backend service aby zistil ze ci existuje taky verif key
        // AK existuje tak daj aj email nech ho mozem vlozit do premennej email
        setEmail("TODO: Email z DB")

    }, [])

    const handleSubmit = (e: any) => {
        e.preventDefault()
        //send data to backend to create user
        setRegistrationSuccessful(true)
        localStorage.setItem("loggedIn", "true")
    }

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-6 homepageForm"}>
                    <form onSubmit={handleSubmit}>
                        <h1 style={{marginBottom: "30px"}}>Získanie údajov o používateľovi</h1>
                        <div className={"row mb-3"}>
                            <div className={"col-6"}>
                                <TextField label={"Meno"} required autoFocus value={name}
                                           onChange={(e) => {
                                               setName(e.target.value)
                                           }}/>
                            </div>
                            <div className={"col-6"}>
                                <TextField label={"Priezvisko"} required value={surname}
                                           onChange={(e) => {
                                               setSurname(e.target.value)
                                           }}/>
                            </div>
                        </div>

                        <div className={"row mb-3"}>
                            <div className={"col-6"}>
                                <TextField label={"Email"} disabled value={email}/>
                            </div>
                            <div className={"col-6"}>
                                <TextField label={"Heslo"} value={password} required
                                           onChange={(e) => {
                                               setPassword(e.target.value)
                                           }} type={"password"} />
                            </div>
                        </div>

                        <div className={"row mb-3 justify-content-center"}>
                            <div className={"col-8"}>
                                <TextField label={"Číslo občianskeho"} required value={idNumber}
                                           onChange={(e) => {
                                               setIdNumber(e.target.value)
                                           }}/>
                            </div>
                        </div>
                        <Button className={"me-2"} type={"submit"} variant={"success"} onClick={() => console.log("")}>Dokončiť registráciu</Button>
                    </form>
                </div>
            </div>
            <MessagePopUp TitleText={"Registrácia úspešná"} BodyText={"Gratulujeme. Úspešne ste sa registrovali."} ButtonUrl={"/profil"} show={registrationSuccessful}/>
        </div>
    )
}

export default GetUserDetailsForm;