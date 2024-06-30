import React from 'react';
import PessoaList from './components/PessoaList';
import PessoaForm from './components/PessoaForm';

const App = () => {
  return (
    <div>
      <h1>Gerenciamento de Pessoas</h1>
      <PessoaForm />
      <PessoaList />
    </div>
  );
};

export default App;
