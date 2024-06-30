import React, { useState } from 'react';
import api from '../services/api';

const PessoaForm = () => {
  const [nome, setNome] = useState('');
  const [cpf, setCpf] = useState('');
  const [dataNascimento, setDataNascimento] = useState('');

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
    } catch (error) {
      console.error("Erro ao adicionar pessoa", error);
    }
  };

  return (
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
  );
};

export default PessoaForm;
