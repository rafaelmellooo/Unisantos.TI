import { FormControl, Input, InputLabel } from '@mui/material';
import React from 'react';
import { IMaskInput } from 'react-imask';

interface CustomProps {
    onChange: (event: { target: { name: string; value: string } }) => void;
    name: string;
}

const TextMaskCustom = React.forwardRef<HTMLElement, CustomProps>(
    function TextMaskCustom(props, ref) {
        const { onChange, ...other } = props;
        return (
            <IMaskInput
                {...other}
                mask="(00) 00000-0000"
                definitions={{
                    '#': /[1-9]/,
                }}
                //inputRef={ref}
                onAccept={(value: any) => onChange({ target: { name: props.name, value } })}
                overwrite
            />
        );
    },
);

interface State {
    textmask: string;
}

export const InputTelefone = () => {
    const [values, setValues] = React.useState<State>({
        textmask: ''
    });

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValues({
            ...values,
            [event.target.name]: event.target.value,
        });
    };

    return (
        <FormControl variant="standard" className="registerField">
            <InputLabel htmlFor="formatted-text-mask-input">Número para contato</InputLabel>
            <Input
                value={values.textmask}
                onChange={handleChange}
                name="textmask"
                id="formatted-text-mask-input"
                inputComponent={TextMaskCustom as any}
            />
        </FormControl>
    )
}