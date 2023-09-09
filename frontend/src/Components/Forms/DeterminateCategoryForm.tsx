import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";

const DeterminateCategoryForm = () => {
    const cases : string[] = [
        "Ste fyzická osoba s trvalým pobytom alebo vlastníckym vzťahom k nehnuteľnosti na uliciach v historickej časti mesta",

        "Ste držiteľom preukazu občana s ťažkým zdravotným \n" +
        "postihnutím alebo preukazu občana s ťažkým zdravotným postihnutím s potrebou sprievodcu? Alebo \n" +
        "ste držiteľom vozidla s preukáztelnou starostlivosťou o držiteľa preukazu občana s ťažkým zdravotným \n" +
        "postihnutím alebo preukazu občana s ťažkým zdravotným postihnutím s potrebou sprievodcu, s trvalým \n" +
        "pobytom, alebo pracoviskom na uliciach v historickej časti mesta",

        "Ste vodičom vozidla na elektrický, alebo vodíkový pohon, alebo hybridné vozidlo, s ktorým sa na \n" +
        "základe zmluvného vzťahu v čase od 06,00 h do 09,00 h zabezpečuje zásobovanie prevádzok v \n" +
        "historickej časti mesta a pristavených lodí z dunajskej promenády",

        "Ste fyzická osoba alebo právnická osoba, s preukázateľnou možnosťou parkovania vozidla v \n" +
        "garáži, alebo v dvornom priestore mimo verejného priestranstva",

        "Ste vodičom vozidla, s ktorým sa na základe zmluvného vzťahu v čase od 06,00 h do 09,00 h \n" +
        "zabezpečujete zásobovanie prevádzok v historickej časti mesta podľa § 2 ods. 2 písm. a), b), c), e) alebo \n" +
        "pristavených lodí z dunajskej promenády podľa § 2 ods. 2 písm. d)",

        "Ste vodičom vozidla zabezpečujúceho čistenie komunikácií, zásahového vozidla SBS alebo vozidla \n" +
        "zabezpečujúceho odvoz komunálneho odpadu v historickej časti mesta",

        "Ste vodičom vozidla zabezpečujúce dovoz a odvoz nákladu rôzneho druhu, alebo opravárenské a \n" +
        "údržbárske práce pre fyzickú osobu, alebo právnickú osobu so vzťahom k nehnuteľnosti na uliciach v \n" +
        "historickej časti mesta",

        "Ste vodičom vozidla, s ktorým sa na základe zmluvného vzťahu zabezpečujete bez časového obmedzenia \n" +
        "zásobovanie pristavených lodí z dunajskej promenády podľa § 2 ods. 2 písm. d)",

        "Ste vodičom vozidla, ktorého držiteľ preukáže zvláštne užívanie komunikácie, alebo osobitné užívanie \n" +
        "verejného priestranstva na uliciach v historickej časti mesta",

        "Ste vodičom vozidla, ktoré má udelenú výnimku pre vjazd orgánom Policajného zboru alebo ministerstvom",

        "Ste vodičom vozidla prepravujúceho účastníkov sobášneho obradu, účastníkov krstu/uvítania detí do \n" +
        "života",

        "Ste vodičom vyhliadkového vozidla právnickej osoby alebo fyzickej osoby oprávnenej na podnikanie"
    ]

    let [caseIndex, setCaseIndex] : [number, any] = useState(0);
    let navigate = useNavigate();

    useEffect(() => {
        if(caseIndex === 12)
            navigate("/ziadost/zamietnuta")
    }, [caseIndex])

    const handleSubmit = (e: any) => {
        e.preventDefault()
        navigate("/ziadost/kategoria/"+caseIndex.toString())
    }

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-6 homepageForm"}>
                    <form onSubmit={handleSubmit}>
                        <h1 style={{marginBottom: "30px"}}>Zaradenie sa do skupiny</h1>
                        <p>{cases[caseIndex]}?</p>
                        <Button className={"me-2"} variant={"danger"} onClick={() => setCaseIndex(caseIndex + 1)}>Nie</Button>
                        <Button className={"me-2"} type={"submit"} variant={"success"}>Áno</Button>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default DeterminateCategoryForm;