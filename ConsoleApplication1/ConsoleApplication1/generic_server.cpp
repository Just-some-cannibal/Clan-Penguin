#include "generic_server.h"



template<typename handler>
void generic_server<handler>::start_server()
{
	boost::asio::ip::tcp::endpoint endpoint (boost::asio::ip::tcp::v4(), port_);
	acceptor_.open(endpoint.protocol());


}

template<typename handler>
void generic_server<handler>::handle_new_connection(shared_handler_t handler,
	const boost::system::error_code & error)
{
}