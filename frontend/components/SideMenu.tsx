import { useState } from "react";
import { useSpring, animated } from "react-spring";
import MenuIcon from '@mui/icons-material/Menu';
import { Chip } from '@mui/material'
import { Close, FilterAlt } from "@mui/icons-material";

export const SideMenu = () => {
    const [opened, setOpened] = useState(false);

    const handleMenuToggle = () => {
        setOpened(opened => !opened);
    }

    const { left } = useSpring({
        from: { left: "-100%" },
        left: opened ? "0" : "-100%"
    });

    return (
        <>
            <div className="menu-button" id="menuButton" onClick={(handleMenuToggle)}>
                <FilterAlt />
            </div>

            <animated.div style={{ left: left }} className="sideMenu">
                <div className="items-container">
                    <div className="filtros-close-container">
                        Filtros
                        <Close />
                    </div>
                    <div className="filter-section">Bares</div>
                    <div className="filter-chip-container">
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                    </div>

                    <div className="filter-section">Bares</div>
                    <div className="filter-chip-container">
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                    </div>

                    <div className="filter-section">Bares</div>
                    <div className="filter-chip-container">
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                    </div>

                    <div className="filter-section">Bares</div>
                    <div className="filter-chip-container">
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip' />
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                        <Chip label="Cerveja" size="small" className='filter-chip'/>
                    </div>
                </div>

                <div className="close-conainer" onClick={handleMenuToggle} />
            </animated.div>
        </>
    );
};