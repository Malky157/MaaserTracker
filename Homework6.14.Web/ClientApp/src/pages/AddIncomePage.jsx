import React, { useState, useEffect } from 'react';
import { Container, TextField, Button, Autocomplete, Typography } from '@mui/material';
import dayjs from 'dayjs';
import axios from 'axios';

const AddIncomePage = () => {

    const [income, setIncome] = useState({
        sourceId: '',
        amount: '',
        date: new Date()
    })

    const [sources, setSources] = useState([{
        id: '',
        incomeSource: ''
    }]);

    const [currentSource, setCurrentSource] = useState(null);


    useEffect(() => {
        const getSources = async () => {
            const { data } = await axios.get('api/source/getallsources');
            setSources(data);
        };
        getSources();
    }, [])

    const onTextChange = e => {
        const copy = { ...income }
        copy[e.target.name] = e.target.value;
        setIncome(copy);

    }

    const onAddClick = async () => {
        income.sourceId = currentSource.id
        await axios.post('api/income/addincome', income)
    }

    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Income
            </Typography>

            <Autocomplete
                options={sources}
                getOptionLabel={(option) => option.incomeSource}
                fullWidth
                margin="normal"
                name='incomeSource'
                value={currentSource}
                onChange={(e, source) => setCurrentSource(source)}
                renderInput={(params) => <TextField {...params} label="Source" />}
            />

            <TextField
                label="Amount"
                variant="outlined"
                type="number"
                value={income.amount}
                InputProps={{ inputProps: { min: 0, step: 0.01 } }}
                fullWidth
                margin="normal"
                onChange={onTextChange}
                name='amount'
            />

            <TextField
                label="Date"
                type="date"
                value={dayjs(income.date).format('YYYY-MM-DD')}
                onChange={onTextChange}
                name='date'
            />

            <Button variant="contained" color="primary" onClick={onAddClick}>Add Income</Button>
        </Container>
    );
}

export default AddIncomePage;
