import React, { useState } from 'react';
import api from '../services/api';
import Error from './Error';

const PessoaForm = ({ onPessoaAdded }) => {
  const [nome, setNome] = useState('');
  const [cpf, setCpf] = useState('');
  const [dataNascimento, setDataNascimento] = useState('');
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.post('/', {
        nome,
        cpf,
        dataNascimento,
      });
      alert('Pessoa adicionada com sucesso!');
      setNome('');
      setCpf('');
      setDataNascimento('');
      setError(null);
      onPessoaAdded(); // Notify parent component about the new person
    } catch (error) {
      setError('Erro ao adicionar pessoa');
    }
  };

  return (
    <div id="adicionar-pessoa" className="container">
      <h2>Adicionar Pessoa</h2>
      {error && <Error message={error} />}
      <form onSubmit={handleSubmit}>
        <div>
          <label>Nome:</label>
          <input type="text" value={nome} onChange={(e) => setNome(e.target.value)} required />
        </div>
        <div>
          <label>CPF:</label>
          <input type="text" value={cpf} onChange={(e) => setCpf(e.target.value)} required />
        </div>
        <div>
          <label>Data de Nascimento:</label>
          <input type="date" value={dataNascimento} onChange={(e) => setDataNascimento(e.target.value)} required />
        </div>
        <button type="submit">Adicionar Pessoa</button>
      </form>
    </div>
  );
};

export default PessoaForm;
