import React, { Component } from "react";
import Axios from "axios";

class Signin extends Component{
    constructor(){
        super();
        this.state = {
            email : '',
            senha : ''
        }
    }

    atualizarStateEmail(event){  this.setState({ email : event.target.value});    }
    atualizarStateSenha(event){  this.setState({ senha : event.target.value});    }

    realizaCadastro(event){
        event.preventDefault();
        
        Axios.post("http://localhost:5000/api/users", {
           email : this.state.email,
           senha: this.state.senha
        })
        .then(data => {
            if(data.status === 200){
                console.log(data);
                this.props.history.push("/");
            } 
        })
        .catch(erro => {
            this.setState({ erroMensagem : 'Email ou senha inválido'});
        })
    }

  render() {
    return (

      <div>

        <div className="form-group">
          <div className="row">
            <form onSubmit={this.realizaCadastro.bind(this)}>
            <label htmlFor="email-cadastro">Email</label>
                <input
                  className="form-control"
                  placeholder="Cadastre seu email"
                  type="email"
                  value={this.state.email}
                  onChange={this.atualizarStateEmail.bind(this)}
                  name="username"
                  id="email-cadastro"
                />
                <label htmlFor="exampleInputPassword1">Password</label>
                <input
                  className="form-control"
                  placeholder="Insira sua senha"
                  value={this.state.senha}
                  onChange={this.atualizarStateSenha.bind(this)}
                  type="password"
                  name="password"
                  id="pass-cadastro"
                />
                <button type="submit" className="btn btn-primary">
                  Submit
                </button>
                <small>Já possui uma conta?</small>
            </form>
          </div>
        </div>
            
      </div>
   
   );
  }
}

export default Signin;