import React, { useState, useEffect } from 'react';
import {
  Checkbox, Container, FormControlLabel, Table, TableBody, TableCell,
  TableContainer, TableHead, TableRow, Paper, Typography
} from '@mui/material';
import axios from 'axios';
import dayjs from 'dayjs';

const IncomePage = () => {

  const [sourcesWithIncomes, setSourcesWithIncomes] = useState([]);
  const [incomes, setIncomes] = useState([]);
  const [groupBySource, setGroupBySource] = useState(false);

  useEffect(() => {
    const getData = () => {
      getIncomes();
      getIncomesGrouped();
    }
    getData();
  }, [])

  const getIncomesGrouped = async (e) => {
    const { data } = await axios.get('api/income/getincomesgrouped');
    setSourcesWithIncomes(data);

  }

  const getIncomes = async () => {
    const { data } = await axios.get('api/income/getincomes');
    setIncomes(data);

  }

  return (
    <Container sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center', mt: 3 }}>
      <Typography variant="h2" gutterBottom component="div">
        Income History
      </Typography>
      <FormControlLabel
        control={
          <Checkbox
            checked={groupBySource}
            onChange={(e) => setGroupBySource(e.target.checked)}
            name="checkedB"
            color="primary"
          />
        }
        label="Group by source"
      />

      {!groupBySource ? (
        <TableContainer component={Paper} sx={{ maxWidth: '80%', width: '80%' }}>
          <Table sx={{ minWidth: 650 }}>
            <TableHead>
              <TableRow>
                <TableCell sx={{ fontSize: '18px' }}>Source</TableCell>
                <TableCell align="right" sx={{ fontSize: '18px' }}>Amount</TableCell>
                <TableCell align="right" sx={{ fontSize: '18px' }}>Date</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {incomes.map((income) => (
                <TableRow key={income.id}>
                  <TableCell component="th" scope="row" sx={{ fontSize: '18px' }}>
                    {income.sourceName}
                  </TableCell>
                  <TableCell align="right" sx={{ fontSize: '18px' }}>${income.amount}</TableCell>
                  <TableCell align="right" sx={{ fontSize: '18px' }}>{dayjs(income.date).format('YYYY-MM-DD')}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      ) : (

        sourcesWithIncomes.map(source => (
          <div key={source.id} sx={{ width: '80%', maxWidth: '80%' }}>
            {!!source.incomes.length && <div>
              <Typography variant="h5" gutterBottom component="div" sx={{ mt: 5 }}>
                {source.incomeSource}
              </Typography>
              <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }}>
                  <TableHead>
                    <TableRow>
                      <TableCell sx={{ fontSize: '18px' }}>Source</TableCell>
                      <TableCell align="right" sx={{ fontSize: '18px' }}>Amount</TableCell>
                      <TableCell align="right" sx={{ fontSize: '18px' }}>Date</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {source.incomes.map((income) => (
                      <TableRow key={income.id}>
                        <TableCell component="th" scope="row" sx={{ fontSize: '18px' }}>
                          {source.incomeSource}
                        </TableCell>
                        <TableCell align="right" sx={{ fontSize: '18px' }}>${income.amount}</TableCell>
                        <TableCell align="right" sx={{ fontSize: '18px' }}>{income.date}</TableCell>
                      </TableRow>
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </div>}
          </div>
        ))
      )
      }
    </Container>
  );
}

export default IncomePage;
