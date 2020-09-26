/*==============================================================*/
/* SCRIPT CARGA_INICIAL  TB_SITUACAO_JOGO                       */
/*==============================================================*/
INSERT INTO TB_SITUACAO_JOGO (DS_SITUACAO) VALUES ('Disponível');
INSERT INTO TB_SITUACAO_JOGO (DS_SITUACAO) VALUES ('Emprestado');

/*==============================================================*/
/* SCRIPT CARGA_INICIAL  TB_TIPO_PLATAFORMA                     */
/*==============================================================*/
INSERT INTO TB_TIPO_PLATAFORMA (DS_PLATAFORMA) VALUES ('Playstation');
INSERT INTO TB_TIPO_PLATAFORMA (DS_PLATAFORMA) VALUES ('Xbox');
INSERT INTO TB_TIPO_PLATAFORMA (DS_PLATAFORMA) VALUES ('Nintendo');

/*==============================================================*/
/* SCRIPT CARGA_INICIAL  TB_TIPO_JOGO                           */
/*==============================================================*/
INSERT INTO TB_TIPO_JOGO (DS_TIPO_JOGO) VALUES ('Ação');
INSERT INTO TB_TIPO_JOGO (DS_TIPO_JOGO) VALUES ('Aventura');
INSERT INTO TB_TIPO_JOGO (DS_TIPO_JOGO) VALUES ('Infantil');
INSERT INTO TB_TIPO_JOGO (DS_TIPO_JOGO) VALUES ('Terror');

/*==============================================================*/
/* SCRIPT CARGA_INICIAL  TB_USUARIO                         */
/*==============================================================*/
INSERT INTO TB_USUARIO (NM_NOME, IN_QTDE_JOGOS_EMPRESTADOS, IN_PODE_TER_ACESSO, IN_STATUS) VALUES ('Valniria Bandeira', 0, 1, 1);