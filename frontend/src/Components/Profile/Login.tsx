import React, {useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";
import TextField from "@material-ui/core/TextField";
import MessagePopUp from "../PopUp/MessagePopUp";

const LoginComponent = () => {
    let navigate = useNavigate();
    let [email, setEmail] : [string, any] = useState("");
    let [password, setPassword] : [string, any] = useState("");
    let [errorMessage, setErrorMessage] : [string, any] = useState("");
    let [loginError, setLoginError] : [boolean, any] = useState(false);

    const handleSubmit = (e: any) => {
        e.preventDefault()
        // Zavolaj backend endpoint aby si zistil ci su prihlasovacie udaje spravne
        if(password == "admin") {
            localStorage.setItem("loggedIn", "true")
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
                            <h1 style={{marginBottom: "30px"}}>Prihlásenie</h1>
                            <TextField label={"Email"} required autoFocus value={email}
                                       onChange={(e) => {
                                           setEmail(e.target.value);
                                           setErrorMessage("");
                                       }} fullWidth type={"email"} />
                            <TextField label={"Heslo"} required value={password}
                                       onChange={(e) => {
                                           setPassword(e.target.value);
                                           setErrorMessage("");
                                       }} fullWidth type={"password"} />
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