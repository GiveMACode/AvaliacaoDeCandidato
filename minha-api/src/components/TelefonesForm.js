import React, { useState } from 'react';
import api from '../services/api';

const TelefonesForm = ({ pessoaId }) => {
  const [tipo, setTipo] = useState('Celular');
  const [numero, setNumero] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await api.put(`/${pessoaId}/telefones`, {
        tipo,
        numero,
      });
      alert('Telefone adicionado com sucesso!');
      setTipo('Celular');
      setNumero('');
    } catch (error) {
      console.error("Erro ao adicionar telefone", error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Tipo:</label>
        <select value={tipo} onChange={(e) => setTipo(e.target.value)}>
          <option value="Celular">Celular</option>
          <option value="Residencial">Residencial</option>
          <option value="Comercial">Comercial</option>
        </select>
      </div>
      <div>
        <label>Número:</label>
        <input type="text" value={numero} onChange={(e) => setNumero(e.target.value)} required />
      </div>
      <button type="submit">Adicionar Telefone</button>
    </form>
  );
};

export default TelefonesForm;
