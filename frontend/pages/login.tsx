import { AccountCircle, VisibilityOff } from '@mui/icons-material'
import { Button, InputAdornment, TextField } from '@mui/material'
import Image from 'next/image'
import Logo from '../public/logo.png'
import {FormEvent, useState} from "react";
import {api} from "../services";
import {useCookies} from "react-cookie";
import {useRouter} from "next/router";

interface CreateSessionAxiosResponse {
    data: {
        token: string;
        refreshToken: string;
    }
}

export default function Login() {
    const [cookies, setCookie] = useCookies(['session-token']);
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [error, setError] = useState('')
    const router = useRouter();

    const handleSubmit = async (event: FormEvent) => {
        event.preventDefault();

        setError('');

        try {
            const response = await api.post<CreateSessionAxiosResponse>('sessions', {
                email, password
            });

            setCookie('session-token', response.data.data.token, {
                path: '/',
                maxAge: 60 * 60 * 24 * 30,
                sameSite: true
            });

            await router.push('/');
        } catch {
            setError('E-mail ou senha incorretos');
        }
    }

    return (
        <>
            <Image
                className='logo-box'
                src={Logo}
                alt="logo"
            />

            <form className="login-box" onSubmit={handleSubmit}>
                <TextField
                    label="E-mail"
                    InputProps={{
                        endAdornment: (
                            <InputAdornment position="end">
                                <AccountCircle />
                            </InputAdornment>
                        )
                        ,
                    }}
                    variant="standard"
                    className="login-input"
                    required
                    type='email'
                    value={email}
                    onChange={event => setEmail(event.target.value)}
                />

                <TextField
                    label="Senha"
                    required
                    type="password"
                    InputProps={{
                        endAdornment: (
                            <InputAdornment position="end">
                                <VisibilityOff />
                            </InputAdornment>
                        )
                        ,
                    }}
                    variant="standard"
                    className="login-input"
                    value={password}
                    onChange={event => setPassword(event.target.value)}
                />

                <p style={{
                    color: '#FF0000',
                }}>{error}</p>

                <Button variant="contained" className="login-button" type='submit'>
                    ENTRAR
                </Button>
                <Button variant="contained" className="login-button">
                    CADASTRE-SE
                </Button>
            </form>
        </>
    )
}