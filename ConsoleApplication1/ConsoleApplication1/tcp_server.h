#pragma once
#include "tcp_connection.h"
#include <boost/asio.hpp>
#include <boost/array.hpp>
#include <boost/property_tree/ptree.hpp>
#include <boost/property_tree/json_parser.hpp>
using boost::asio::ip::tcp;
class tcp_server
{
public:
	tcp_server(boost::asio::io_service& io_service);

	~tcp_server();
private:
	void start_accept();
	void handle_accept(tcp_connection::pointer new_connection,
		const boost::system::error_code& error);
	tcp::acceptor acceptor_;
};

