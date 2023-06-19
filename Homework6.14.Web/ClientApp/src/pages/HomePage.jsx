import React from 'react';
import { Button, Container, Typography, Box } from '@mui/material';
import { Link } from 'react-router-dom';

const HomePage = () => {
  return (
    <Container
      sx={{
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        height: '80vh',
        textAlign: 'center'
      }}
    >
      <Typography variant="h2" component="h1" gutterBottom>
        Welcome to the Maaser Tracker
      </Typography>
      <Typography variant="h6" component="h2" gutterBottom>
        עַשֵּׂר תְּעַשֵּׂר אֵת כָּל-תְּבוּאַת זַרְעֶךָ, הַיֹּצֵא הַשָּׂדֶה שָׁנָה שָׁנָה." - דברים י"ד, כ"ב"
      </Typography>
    </Container>
  );
}

export default HomePage;
