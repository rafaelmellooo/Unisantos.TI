/* eslint-disable react/no-unescaped-entities */
import Image from 'next/image'
import { WhatsApp, PinDrop, AccessTime, Phone, Facebook, Instagram } from '@mui/icons-material'

export default function EstablishmentInfo() {
    return (
        <>
            <div className="stb-image-title-container">
                <div className="stb-image">
                </div>
                <div className='stb-title'>Arapuka's Bar</div>
            </div>
            <div className="stb-info">
                <div className='info'>
                   <div className='stb-icon'> <PinDrop/> </div>
                    <div className='stb-text'>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.   
                     </div> 
                </div>
                <div className='info'>
                   <div className='stb-icon'> <AccessTime/> </div>
                    <div className='stb-text'>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.   
                     </div> 
                </div>
                <div className='info'>
                   <div className='stb-icon'> <Phone/> </div>
                    <div className='stb-text'>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.   
                     </div> 
                </div>
                <div className='info'>
                   <div className='stb-icon'> <WhatsApp/> </div>
                    <div className='stb-text'>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.   
                     </div> 
                </div>
                <div className='info'>
                   <div className='stb-icon'> <Facebook/> </div>
                    <div className='stb-text'>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.   
                     </div> 
                </div>
                <div className='info'>
                   <div className='stb-icon'> <Instagram/> </div>
                    <div className='stb-text'>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit.   
                     </div> 
                </div>
            </div>
        </>
    )
} 