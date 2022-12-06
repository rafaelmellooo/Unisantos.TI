import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { Checkbox, FormControlLabel, FormGroup, TextField } from '@mui/material';
import React, { useState } from 'react';
import { InputTelefone } from '../../components/InputTelefone';

const daysOfWeek = [
    { day: 0, name: "Domingo" },
    { day: 1, name: "Segunda" },
    { day: 2, name: "Terça" },
    { day: 3, name: "Quarta" },
    { day: 4, name: "Quinta" },
    { day: 5, name: "Sexta" },
    { day: 6, name: "Sábado" },
]

export default function NewCompany() {
    const [dayOfWeekChecked, setDayOfWeekChecked] = useState([false, false, false, false, false, false, false])

    const handleDayOfWeekCheckChange = (id: number) => {
        let aux = [...dayOfWeekChecked];
        aux[id] = !aux[id];
        setDayOfWeekChecked(aux);
    }

    return (
        <>
            <div className="registerHeader">
                <ArrowBackIcon />
                <div className='registerTitle'>Novo Estabelecimento</div>
            </div>

            <div className="registerForm">
                <div className="registerSectionTitle">
                    Informações Básicas
                </div>

                <div className="registerSectionContent">
                    <TextField
                        label="Nome"
                        variant="standard"
                        className="registerField"
                    />

                    <TextField
                        label="Descrição"
                        variant="standard"
                        className="registerField"
                        multiline
                    />

                    <InputTelefone />

                    <TextField
                        label="Instagram"
                        variant="standard"
                        className="registerField"
                    />

                    <TextField
                        label="Facebook"
                        variant="standard"
                        className="registerField"
                    />
                </div>

                <div className="registerSectionTitle">
                    Horário de Funcionamento
                </div>

                <div className="registerSectionContent">
                    {daysOfWeek.map(dayOfWeek => (
                        <FormGroup className="registerField" row key={dayOfWeek.day}>
                            <FormControlLabel
                                control={<Checkbox checked={dayOfWeekChecked[dayOfWeek.day]}
                                    onChange={() => handleDayOfWeekCheckChange(dayOfWeek.day)} />}
                                label={dayOfWeek.name}
                                className="registerFieldDay"
                            />

                            <TextField
                                label="Abre"
                                variant="standard"
                                className="registerFieldHour"
                                disabled={!dayOfWeekChecked[dayOfWeek.day]}
                            />

                            <TextField
                                label="Fecha"
                                variant="standard"
                                className="registerFieldHour"
                                disabled={!dayOfWeekChecked[dayOfWeek.day]}
                            />
                        </FormGroup>
                    ))}
                </div>

                <div className="registerSectionTitle">
                    Endereço
                </div>

                <div className="registerSectionContent">
                    <TextField
                        label="CEP"
                        variant="standard"
                        className="registerField"
                    />

                    <TextField
                        label="Logradouro"
                        variant="standard"
                        className="registerField"
                    />

                    <TextField
                        label="Número"
                        variant="standard"
                        className="registerField"
                    />

                    <TextField
                        label="Complemento"
                        variant="standard"
                        className="registerField"
                    />

                    <TextField
                        label="Bairro"
                        variant="standard"
                        className="registerField"
                    />

                    <TextField
                        label="Cidade"
                        variant="standard"
                        className="registerField"
                    />
                </div>
            </div>
        </>
    )
}