import {WhatsApp, PinDrop, Phone, Facebook, Instagram, StarBorder, Star} from '@mui/icons-material';
import { Chip, Rating } from '@mui/material';
import { api } from '../../services';
import {CompanyDetails} from "../../interfaces/CompanyDetails";
import {useCookies} from "react-cookie";

interface ShowCompanyDetailsProps {
    id: string;
    companyDetails: CompanyDetails;
}

export default function ShowCompanyDetails({ id, companyDetails }: ShowCompanyDetailsProps) {
    const [cookies, setCookie] = useCookies(['session-token']);

    const handleFavorite = async () => {
        console.log(cookies["session-token"]);

        try {
            await api.post(`/companies/${id}/favorites`, null, {
                headers: {
                    Authorization: `Bearer ${cookies["session-token"]}`
                }
            });
        } catch {
            alert('Erro ao favoritar');
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
                        src={companyDetails.imageUrl || '/images/semimagem.png'}
                        alt="estabelecimento"
                    />
                </div>
                <div className='stb-title'>{companyDetails.name} {companyDetails.isFavorited ? <Star color='warning' fontSize='medium' /> : <StarBorder onClick={handleFavorite} color='warning' fontSize='medium' style={{
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
            <h3>Avaliações</h3>
            {companyDetails.rates.map(rates => (
                <div key={rates.id} className='rate-container'>
                    <div className='rate-username-container'>
                        <div className='rate-username'>{rates.user}</div>
                        <Rating name="read-only" value={rates.rate} readOnly size='small' />
                    </div>
                    <div className='rate-text'>
                        {rates.comment}
                    </div>
                </div>
            ))}

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
        </>
    )
}

interface AxiosResponse {
    data: CompanyDetails;
}

export async function getServerSideProps({ params }: any) {
    const response = await api.get<AxiosResponse>(`/companies/${params.id}`);

    return {
        props: {
            id: params.id,
            companyDetails: response.data.data
        }
    }
}