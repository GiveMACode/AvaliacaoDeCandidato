import React, { useState, useEffect, forwardRef, useImperativeHandle } from 'react';
import api from '../services/api';
import Error from './Error';

const PessoaList = forwardRef((props, ref) => {
  const [pessoas, setPessoas] = useState([]);
  const [error, setError] = useState(null);

  const fetchPessoas = async () => {
    try {
      const response = await api.get('/');
      setPessoas(response.data);
      setError(null);
    } catch (error) {
      setError('Erro ao buscar pessoas');
    }
  };

  const handleDelete = async (id) => {
    try {
      await api.delete(`/${id}`);
      fetchPessoas(); // Refresh the list
    } catch (error) {
      setError('Erro ao deletar pessoa');
    }
  };

  useImperativeHandle(ref, () => ({
    fetchPessoas
  }));

  useEffect(() => {
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
            <button onClick={() => handleDelete(pessoa.id)}>Excluir</button>
          </li>
        ))}
      </ul>
    </div>
  );
});

export default PessoaList;
