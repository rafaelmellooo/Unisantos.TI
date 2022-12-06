import { WhatsApp, PinDrop, Phone, Facebook, Instagram, StarBorder, Star } from '@mui/icons-material';
import { Chip, Rating, TextField, Button } from '@mui/material';
import { api } from '../../services';
import {CompanyDetails} from "../../interfaces/CompanyDetails";
import {useCookies} from "react-cookie";
import {FormEvent, useState} from "react";
import {Rate} from "../../interfaces/Rate";

interface ShowCompanyDetailsProps {
    id: string;
    companyDetails: CompanyDetails;
}

export default function ShowCompanyDetails({ id, companyDetails }: ShowCompanyDetailsProps) {
    const [cookies, setCookie] = useCookies(['session-token']);
    const [isFavorited, setIsFavorited] = useState(companyDetails.isFavorited);
    const [rates, setRates] = useState(companyDetails.rates);
    const [rate, setRate] = useState<number | null>();
    const [comment, setComment] = useState('');

    const handleFavorite = async (e: FormEvent) => {
        e.preventDefault();

        try {
            await api.post(`/companies/${id}/favorites`, null, {
                headers: {
                    Authorization: `Bearer ${cookies["session-token"]}`
                }
            });

            setIsFavorited(true);
        } catch {
            alert('Erro ao favoritar');
        }
    }

    interface RateCompanyResponse {
        data: Rate;
    }

    const handleComment = async (e: FormEvent) => {
        e.preventDefault();

        try {
            const response = await api.post<RateCompanyResponse>(`/companies/${id}/rates`, {
                rate,
                comment
            }, {
                headers: {
                    Authorization: `Bearer ${cookies["session-token"]}`
                }
            });

            setRates([...rates, response.data.data]);
        } catch {
            alert('Erro ao comentar');
        }
    }

    return (
        <>
            <div className="stb-image-title-container">
                <div className="stb-image-container">
                    <img
                        className='stb-image'
                        height={200}
                        width={'100%'}
                        src={companyDetails.imageUrl}
                        alt={`Imagem do estabelecimento ${companyDetails.name}`}
                    />
                </div>
                <div className='stb-title'>{companyDetails.name} {isFavorited ? <Star color='warning' fontSize='medium' /> : <StarBorder onClick={handleFavorite} color='warning' fontSize='medium' style={{
                    cursor: "pointer"
                }} />}</div>
            </div>
            <div className="stb-info">
                <div className='info'>
                    <div className='stb-icon'> <PinDrop /> </div>
                    <div className='stb-text'>
                        {companyDetails?.address.street} - {companyDetails?.address.number} - {companyDetails?.address.neighborhood}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <Phone /> </div>
                    <div className='stb-text'>
                        {companyDetails?.phone}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <WhatsApp /> </div>
                    <div className='stb-text'>
                        {companyDetails?.phone}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <Facebook /> </div>
                    <div className='stb-text'>
                        {companyDetails?.facebook}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <Instagram /> </div>
                    <div className='stb-text'>
                        {companyDetails?.instagram}
                    </div>
                </div>
            </div>
            <div className='stb-categories'>
                {companyDetails.tags.map(tag => (
                    <Chip key={tag} label={tag} className='stb-chip' />
                ))}
            </div>
            <div className='stb-description'>
                {companyDetails.description}
            </div>

            <h3>Cardápio</h3>
            {companyDetails.productsSections.map(productsSection => (
                <div key={productsSection.id}>
                    <div className='product-title'>
                        {productsSection.title}
                    </div>
                    {productsSection.products.map(product => (
                        <div key={product.id} className='product'>
                            <div className='product-name-price'>
                                <div>{product.name}</div>
                                <div>{product.price}</div>
                            </div>
                            <div className='product-description'>
                                {product.description}
                            </div>
                        </div>
                    ))}

                </div>
            ))}

            <h3>Avaliações</h3>
            {rates.map(rate => (
                <div key={rate.id} className='rate-container'>
                    <div className='rate-username-container'>
                        <div className='rate-username'>{rate.user}</div>
                        <Rating name="read-only" value={rate.rate} readOnly size='small' />
                    </div>
                    <div className='rate-text'>
                        {rate.comment}
                    </div>
                </div>
            ))}
            <form className='rate-container' onSubmit={handleComment}>
                <div className='rate-username-container'>
                    <div className='rate-username'>Você</div>
                    <Rating value={rate} onChange={(e, newValue) => setRate(newValue)} size='small' />
                </div>
                <div className='user-comment'>
                    <TextField
                        label="Comentário"
                        multiline
                        rows={4}
                        fullWidth
                        value={comment}
                        onChange={e => setComment(e.target.value)}
                    />
                </div>
                <div className='comment-button-container'>
                    <Button variant="contained" className='comment-button' type="submit">Enviar</Button>
                </div>
            </form>
        </>
    )
}

interface AxiosResponse {
    data: CompanyDetails;
}

export async function getServerSideProps({ req, params }: any) {
    if (req.cookies['session-token']) {
        const response = await api.get<AxiosResponse>(`/companies/${params.id}`, {
            headers: {
                Authorization: `Bearer ${req.cookies['session-token']}`
            }
        });

        return {
            props: {
                id: params.id,
                companyDetails: response.data.data
            }
        }
    }

    const response = await api.get<AxiosResponse>(`/companies/${params.id}`);

    return {
        props: {
            id: params.id,
            companyDetails: response.data.data
        }
    }
}