import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate, useParams} from "react-router-dom";
import {UtilService} from "../../Service/UtilService";
import validator from "validator";
import isNumeric = validator.isNumeric;
import TextField from "@material-ui/core/TextField";
import MessagePopUp from "../PopUp/MessagePopUp";

const CompleteRequestForm = () => {
    let navigate = useNavigate();
    const { caseIndex } = useParams();
    let [requestPrices, setRequestPrices]: [number[], any] = useState([0, 0])
    let [licensePlate, setLicensePlate]: [string, any] = useState("")
    let [startDate, setStartDate]: [string, any] = useState("")
    let [isYearly, setIsYearly]: [boolean, any] = useState(false)
    let [requestSent, setRequestSent]: [boolean, any] = useState(false)

    useEffect(() => {
        if(caseIndex === undefined || !isNumeric(caseIndex) || Number(caseIndex) < 0 || Number(caseIndex) > 11)
            navigate("/404")
        else{
            setRequestPrices([UtilService.CalculateTaxAmountForRequest(Number(caseIndex), false), UtilService.CalculateTaxAmountForRequest(Number(caseIndex), true)])
        }
    }, [caseIndex])

    const handleSubmit = (e: any) => {
        e.preventDefault()
        //Call backend to register a request
        setRequestSent(true)
    }

    const handleFile = (e: any) => {
        console.log(e.target.files)
    }

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-6 homepageForm"} style={{marginBottom: "200px", textDecoration: "none"}}>
                    <form onSubmit={handleSubmit}>
                        <h1 style={{marginBottom: "30px"}}>Dokončenie požidadavky o židaosť</h1>
                        <div className={"row mb-2"}>
                            <div className={"col-6"}>
                                    <Button className={"me-2"} onClick={() => setIsYearly(false)} variant={"primary"}>Deň</Button>
                                    <Button className={"me-2"} disabled={requestPrices[1] === 0} onClick={() => setIsYearly(true)} variant={requestPrices[1] === 0 ? "outline-secondary" : "secondary"}>Rok</Button>
                            </div>
                            <div className={"col-6"}>
                                <TextField label={"Cena"} disabled value={!isYearly ? requestPrices[0] : requestPrices[1] }/>
                            </div>
                        </div>
                        <div className={"row mb-4"}>
                            <div className={"col-6"}>
                                <TextField  label={"EČV vozidla"} required value={licensePlate} onChange={(e) => {setLicensePlate(e.target.value)}}/>
                            </div>
                            <div className={"col-6"}>
                                <TextField type={"date"} required style={{marginTop: "15px", width: "195px"}} value={startDate} onChange={(e) => {setStartDate(e.target.value)}}/>
                            </div>
                        </div>
                        <div className={"row mb-4 justify-content-center"}>
                            <p>Dolžiť doklady:</p>
                            <input style={{marginLeft: "325px"}} type="file" name="images" id="imgid" className="imgcls" onChange={handleFile} multiple/>
                        </div>
                        <Button className={"me-2"} onClick={() => navigate("/profil/ziadosti")} variant={"danger"}>Zrušiť</Button>
                        <Button className={"me-2"} type={"submit"} variant={"success"}>Potvrdiť</Button>
                    </form>
                </div>
            </div>
            <MessagePopUp TitleText={"Žiadosť je evidovaná"} BodyText={"Ďakujeme Vám za vyplennenie žiadosti. Žiadosť sme obdržali. Prehľad stavu žiadostí si môžete prezrieť v profile."} ButtonUrl={"/profil/ziadosti"} show={requestSent} ButtonText={"Zobraziť prehľad židaostí"}/>
        </div>
    )
}

export default CompleteRequestForm;