import React, { useState, useEffect } from 'react';
import api from '../services/api';

const PessoaList = () => {
  const [pessoas, setPessoas] = useState([]);

  useEffect(() => {
    const fetchPessoas = async () => {
      try {
        const response = await api.get('/');
        setPessoas(response.data);
      } catch (error) {
        console.error("Erro ao buscar pessoas", error);
      }
    };

    fetchPessoas();
  }, []);

  return (
    <div>
      <h1>Lista de Pessoas</h1>
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
