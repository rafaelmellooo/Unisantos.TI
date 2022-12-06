/* eslint-disable @next/next/no-img-element */
/* eslint-disable react/no-unescaped-entities */
import { WhatsApp, PinDrop, AccessTime, Phone, Facebook, Instagram } from '@mui/icons-material'
import { Chip, Rating } from '@mui/material'
import { Company, ProductsSection } from '../../interfaces/Company';
import { api } from '../../services';


interface HomeProps {
    companies: Company;
}

export default function EstablishmentInfo({ companies }: HomeProps) {
    return (
        <>
            <div className="stb-image-title-container">
                <div className="stb-image-container">
                    <img
                        className='stb-image'
                        height={200}
                        width={'100%'}
                        src={companies.imageUrl ? companies.imageUrl : ''}
                        alt="estabelecimento"
                    />
                </div>
                <div className='stb-title'>{companies.name}</div>
            </div>
            <div className="stb-info">
                <div className='info'>
                    <div className='stb-icon'> <PinDrop /> </div>
                    <div className='stb-text'>
                        {companies?.address.street} - {companies?.address.number} - {companies?.address.neighborhood}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <Phone /> </div>
                    <div className='stb-text'>
                        {companies?.phone}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <WhatsApp /> </div>
                    <div className='stb-text'>
                        {companies?.phone}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <Facebook /> </div>
                    <div className='stb-text'>
                        {companies?.facebook}
                    </div>
                </div>
                <div className='info'>
                    <div className='stb-icon'> <Instagram /> </div>
                    <div className='stb-text'>
                        {companies?.instagram}
                    </div>
                </div>
            </div>
            <div className='stb-categories'>
                {companies.tags.map(tag => (
                    <Chip key={tag} label={tag} className='stb-chip' />
                ))}
            </div>
            <div className='stb-description'>
                {companies.description}
            </div>
            <h3>Avaliações</h3>
            {companies.rates.map(rates => (
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
            {companies.productsSections.map(productSection => (
                <div key={productSection.id}>
                <div className='product-title'>
                    {productSection.title}
                </div>
                {productSection.products.map(product => (
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
    data: Company[];
}

export async function getServerSideProps({ params }: any) {
    const response = await api.get<AxiosResponse>(`/companies/${params.id}`);

    return {
        props: {
            companies: response.data.data,
            googleMapsApiKey: process.env.GOOGLE_MAPS_API_KEY
        }
    }
}