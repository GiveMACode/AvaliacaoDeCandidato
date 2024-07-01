import React, { useState, useEffect } from 'react';
import api from '../services/api';
import Error from './Error';

const PessoaList = () => {
  const [pessoas, setPessoas] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchPessoas = async () => {
      try {
        const response = await api.get('/');
        setPessoas(response.data);
      } catch (error) {
        setError('Erro ao buscar pessoas');
      }
    };

    fetchPessoas();
  }, []);

  return (
    <div id="listar-pessoas" className="container">
      <h2>Lista de Pessoas</h2>
      {error && <Error message={error} />}
      <ul>
        {pessoas.map((pessoa) => (
          <li key={pessoa.id}>
            {pessoa.nome} - {pessoa.cpf}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PessoaList;
