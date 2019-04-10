import React, { Component } from "react";
import Axios from "axios";

class ListarporUser extends Component {
  constructor(){
      super();
      this.state = {
        lista : [],
        wishDescription: "",
        tituloPagina : "Listagem dos desejos"
      }

      this.listarDesejos = this.listarDesejos.bind(this);
      this.atualizaDesejos = this.atualizaDesejos.bind(this);
      this.adicionarDesejo = this.adicionarDesejo.bind(this);
  }

  listarDesejos(){
      fetch('http://localhost:5000/api/wishes/SeusDesejos')
        .then(resposta => resposta.json())
        .then(data => this.setState({lista : data}))
        .catch((erro) => console.log(erro))
  }

  componentDidMount(){
      this.listarDesejos();
  }

  atualizaDesejos(event){
    this.setState({ wishDescription : event.target.value });
  }



  adicionarDesejo(event){
    event.preventDefault();
    fetch('http://localhost:5000/api/wishes',
    {
      method: 'POST',
      body : JSON.stringify({ wishDescription : this.state.wishDescription }),
          headers: {
            "Content-Type" : "application/json",
            "Authorization" : "Bearer " + localStorage.getItem("usuario")
          }
        })
        .then(resposta => console.log(resposta))
        .then(this.listarDesejos())
        .catch(erro => console.log(erro))
  }

  render() {
    return (
      <div className="imagem">

        <main className="conteudoPrincipal">
          <section className="conteudoPrincipal-cadastro">

            <div className="container" id="conteudoPrincipal-lista">
              <table className="table table"id="tabela-lista">
                <thead className="cor">
                  <tr className="table-primary">
                    <th>#</th>
                    <th>Data Criação</th>
                    <th>Desejos</th>
                  </tr>
                </thead>
                <tbody className="cor">
                    {
                        this.state.lista.map(function(wishes){
                            return (
                                <tr key = {wishes.wishId}>
                                    <td scope="col">{wishes.wishId}</td>
                                    <td scope="col">{wishes.wishCreation}</td>
                                    <td scope="col">{wishes.wishDescription}</td>
                                </tr>
                            );
                        })
                    }
                </tbody>
              </table>
            </div>

            <div className="container" id="conteudoPrincipal-cadastro">

              <form onSubmit={this.adicionarDesejo}>
                <div className="container">
                  <input
                    type="text"
                    value={this.state.wishDescription}
                    onChange={this.atualizaDesejos}
                    id="desejo"
                    placeholder="faça seu desejo"
                  />
                  
                  <button className="btn btn-lg btn-primary text-uppercase">
                    Cadastrar
                  </button>
                </div>
              </form>
            </div>
          </section>
        </main>

      </div>
    );
  }
}

export default ListarporUser;