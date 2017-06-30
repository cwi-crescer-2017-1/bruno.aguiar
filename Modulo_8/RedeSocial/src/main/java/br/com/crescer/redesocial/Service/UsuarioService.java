package br.com.crescer.redesocial.Service;

import br.com.crescer.redesocial.Entity.Usuario;
import br.com.crescer.redesocial.Repositorio.UsuarioRepositorio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

/**
 *
 * @author bruno.aguiar
 */

@Service
public class UsuarioService {
    
    @Autowired
    UsuarioRepositorio repositorio;
    
    public Iterable<Usuario> listar(){
        return repositorio.findAll();
    }
    
    public Usuario cadastrar(Usuario u){
        u.setSenha(new BCryptPasswordEncoder().encode(u.getSenha()));
        return repositorio.save(u);
    }
    
    public void Excluir(Usuario u){
        repositorio.delete(u);
    }
    
    public Usuario buscarPorNome(String nome){
        return repositorio.findByNome(nome);
    }
    
    public Usuario buscarPorEmail(String email){
        return repositorio.findByEmail(email);
    }
}