import React, { useState } from 'react';
import { Container, TextField, Button, Typography } from '@mui/material';
import dayjs from 'dayjs';
import axios from 'axios';


const AddMaaserPage = () => {
    const [maaser, setMaaser] = useState({
        recipient: '',
        amount: '',
        date: new Date()
    });

    const onTextChange = (e) => {
        const copy = { ...maaser };
        copy[e.target.name] = e.target.value;
        setMaaser(copy);
    }

    const add = async () => {
        await axios.post('api/maaser/addmaaser', maaser)
    }

    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Maaser
            </Typography>
            <TextField label="Recipient" variant="outlined" fullWidth margin="normal" name='recipient' onChange={onTextChange} />
            <TextField label="Amount" variant="outlined" fullWidth margin="normal" name='amount' onChange={onTextChange} />
            <TextField
                label="Date"
                type="date"
                value={dayjs(maaser.date).format('YYYY-MM-DD')}
                onChange={onTextChange}                
            />
            <Button variant="contained" color="primary" onClick={add}>Add Maaser</Button>
        </Container>
    );
}

export default AddMaaserPage;
