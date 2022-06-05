import React, { useState } from 'react';
import Products from '../Components/Products';
import Feed from "react-instagram-embed";
import { LinkedInEmbed } from 'react-social-media-embed';
import { TikTokEmbed } from 'react-social-media-embed';
import { InstagramEmbed } from 'react-social-media-embed';
import { FacebookEmbed } from 'react-social-media-embed';



const Home = () => {
    return (
        <div className= "hero">
            <div style={{ display: 'flex', justifyContent: 'center' }}>
                <TikTokEmbed url="https://www.tiktok.com/@epicgardening/video/7055411162212633903" width={325} />
            </div>


        </div>

    );
};

export default Home;