import React, { useRef } from 'react';
import Navbar from './components/Navbar';
import PessoaList from './components/PessoaList';
import PessoaForm from './components/PessoaForm';
import './App.css';

const App = () => {
  const pessoaListRef = useRef();

  const handlePessoaAdded = () => {
    if (pessoaListRef.current) {
      pessoaListRef.current.fetchPessoas();
    }
  };

  return (
    <div>
      <Navbar />
      <PessoaForm onPessoaAdded={handlePessoaAdded} />
      <PessoaList ref={pessoaListRef} />
    </div>
  );
};

export default App;
